using System;

using R5T.T0141;


namespace R5T.T0146.Construction
{
	[DemonstrationsMarker]
	public partial interface IDemonstrations : IDemonstrationsMarker
	{
		public void Success_ToString()
        {
			var success = T0146.Instances.ResultOperator.Success();

			Console.WriteLine(T0146.Instances.ResultOperator.ToString(success));
        }
	}
}