using Unity.Collections;
using Unity.Entities;

namespace HSE.User
{
    public struct UserName: IComponentData
    {
        public FixedString32Bytes Value;
    }
}
