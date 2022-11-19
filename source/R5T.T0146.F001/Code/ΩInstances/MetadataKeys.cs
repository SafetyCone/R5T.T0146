using System;


namespace R5T.T0146.F001
{
	public class MetadataKeys : IMetadataKeys
	{
		#region Infrastructure

	    public static IMetadataKeys Instance { get; } = new MetadataKeys();

	    private MetadataKeys()
	    {
        }

	    #endregion
	}
}