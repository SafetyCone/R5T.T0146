using System;

using R5T.T0131;


namespace R5T.T0146.F001
{
	[ValuesMarker]
	public partial interface IMetadataKeys : IValuesMarker
	{
		public string Index => "Index";
		public string Key => "Key";
	}
}