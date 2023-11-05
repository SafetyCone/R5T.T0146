using System;


namespace R5T.T0146.F001
{
    public static class Instances
    {
        public static F0000.IEqualityOperator EqualityOperator => F0000.EqualityOperator.Instance;
        public static L0053.INullOperator NullOperator => F0000.NullOperator.Instance;
        public static F0000.IMessageOperator MessageOperator => F0000.MessageOperator.Instance;
        public static IMetadataKeys MetadataKeys => F001.MetadataKeys.Instance;
        public static IResultOperator ResultOperator => T0146.ResultOperator.Instance;
        public static L0053.ITypeOperator TypeOperator => L0053.TypeOperator.Instance;
    }
}