using System;

namespace Code.Utils
{
	[AttributeUsage(AttributeTargets.Field)]
	public class InjectFieldAttribute : Attribute
	{
		public string FieldName { get; }

		public InjectFieldAttribute(string fieldName)
		{
			FieldName = fieldName;
		}
	}
}