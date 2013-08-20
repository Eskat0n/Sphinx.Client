namespace Sphinx.Client.Commands.Attributes.Values
{
    using System.Collections.Generic;
    using IO;

    public class AttributeValuesInt64 : AttributeValueBase, IAttributeValues<long>
    {
        private readonly List<long> _values;

        internal AttributeValuesInt64()
        {
            _values = new List<long>();
        }

        public AttributeValuesInt64(string name, IEnumerable<long> values)
            : base(name)
        {
            _values.AddRange(values);
        }

        public override AttributeType AttributeType
        {
            get
            {
                return AttributeType.MultiLong;
            }
        }

        public IList<long> Values
        {
            get { return _values; }
        }

        public override object GetValue()
        {
            return Values;
        }

        internal override void Deserialize(IBinaryReader reader, AttributeInfo attributeInfo)
        {
            base.Deserialize(reader, attributeInfo);
            int count = reader.ReadInt32() / 2;
            for (int i = 0; i < count; i++)
            {
                _values.Add(reader.ReadInt64());
            }
        }
    }
}