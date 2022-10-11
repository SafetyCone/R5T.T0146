using System;


namespace R5T.T0146
{
	public class ResultSerializer : IResultSerializer
	{
		#region Infrastructure

	    public static IResultSerializer Instance { get; } = new ResultSerializer();

	    private ResultSerializer()
	    {
        }

	    #endregion
	}
}