using System;
using System.Dynamic;

namespace App
{
    public class BenchSample : DynamicObject
    {
        public const string PublicSumMethod = nameof(PublicSum);
        public const string ProtectedSumMethod = nameof(ProtectedSum);
        public const string PrivateSumMethod = nameof(PrivateSum);

        public int PublicSum(int left, int right) => left + right;
        protected int ProtectedSum(int left, int right) => left + right;
        private int PrivateSum(int left, int right) => left + right;

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            switch (binder.Name)
            {
                case nameof(ProtectedSum):
                {
                    var left = Convert.ToInt32(args[0]);
                    var right = Convert.ToInt32(args[1]);
                    result = ProtectedSum(left, right);
                    return true;
                }
                case nameof(PrivateSum):
                {
                    var left = Convert.ToInt32(args[0]);
                    var right = Convert.ToInt32(args[1]);
                    result = PrivateSum(left, right);
                    return true;
                }
                default:
                    return base.TryInvokeMember(binder, args, out result);
            }
        }
    }
}
