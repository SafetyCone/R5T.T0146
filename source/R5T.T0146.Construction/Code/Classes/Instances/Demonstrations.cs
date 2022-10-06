using System;


namespace R5T.T0146.Construction
{
	public class Demonstrations : IDemonstrations
	{
		#region Infrastructure

	    public static Demonstrations Instance { get; } = new();

	    private Demonstrations()
	    {
        }

	    #endregion
	}
}