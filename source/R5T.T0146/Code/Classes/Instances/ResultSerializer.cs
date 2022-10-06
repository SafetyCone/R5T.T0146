using System;


namespace R5T.T0146
{
	public class ResultSerializer : IResultSerializer
	{
		#region Infrastructure

	    public static ResultSerializer Instance { get; } = new();

	    private ResultSerializer()
	    {
        }

	    #endregion
	}
}