using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAMetaDataViewer
{
    public class MetaData : IEnumerable<MetaDataElement>
    {
        private List<MetaDataElement> _elements;

        private Encoding _encoding = Encoding.GetEncoding(949);

        public MetaData()
        {
            _elements = new List<MetaDataElement>();
        }

        public MetaData(Stream stream) : this()
        {
            Init(stream);
        }

        public List<MetaDataElement> Elements
        {
            get
            {
                return _elements;
            }
        }

        public MetaDataElement this[int index]
        {
            get
            {
                return _elements[index];
            }

            set
            {
                _elements[index] = value;
            }
        }

        public void Write(Stream stream)
        {
            using (var writer = new BinaryWriter(stream, _encoding, true))
            {
                writer.Write((byte)(_elements.Count / 256));
                writer.Write((byte)(_elements.Count % 256));
                foreach (var element in _elements)
                {
                    byte[] elementTextBytes = _encoding.GetBytes(element.Text);
                    writer.Write((byte)elementTextBytes.Length);
                    writer.Write(elementTextBytes);
                    writer.Write((byte)(element.Values.Count / 256));
                    writer.Write((byte)(element.Values.Count % 256));
                    foreach (var value in element.Values)
                    {
                        byte[] valueBytes = _encoding.GetBytes(value);
                        writer.Write((byte)(valueBytes.Length / 256));
                        writer.Write((byte)(valueBytes.Length % 256));
                        writer.Write(valueBytes);
                    }
                }
            }
        }

        public IEnumerator<MetaDataElement> GetEnumerator()
        {
            return ((IEnumerable<MetaDataElement>)_elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<MetaDataElement>)_elements).GetEnumerator();
        }

        private void Init(Stream stream)
        {
            using (var reader = new BinaryReader(stream, _encoding, true))
            {
                int numberOfElements = reader.ReadByte() << 8 | reader.ReadByte();

                for (int i = 0; i < numberOfElements; ++i)
                {
                    int elementTextLength = reader.ReadByte();
                    byte[] elementTextBytes = reader.ReadBytes(elementTextLength);
                    string elementText = _encoding.GetString(elementTextBytes);

                    var element = new MetaDataElement(elementText);

                    int numberOfValues = reader.ReadByte() << 8 | reader.ReadByte();

                    for (int j = 0; j < numberOfValues; ++j)
                    {
                        int valueLength = reader.ReadByte() << 8 | reader.ReadByte();
                        byte[] valueBytes = reader.ReadBytes(valueLength);
                        string value = _encoding.GetString(valueBytes);
                        element.Values.Add(value);
                    }

                    _elements.Add(element);
                }
            }
        }
    }

    public class MetaDataElement : IEnumerable<string>
    {
        private string _text;
        private List<string> _values;

        public MetaDataElement(string text)
        {
            _text = text;
            _values = new List<string>();
        }

        public MetaDataElement(string text, IEnumerable<string> values) : this(text)
        {
            _values.AddRange(values);
        }

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
            }
        }

        public List<string> Values
        {
            get
            {
                return _values;
            }
        }

        public string this[int index]
        {
            get
            {
                return _values[index];
            }

            set
            {
                _values[index] = value;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string>)_values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<string>)_values).GetEnumerator();
        }
    }
}
