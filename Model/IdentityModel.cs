namespace vstaskmgr.Model
{
    public enum IdentityType
    {
        IdCard = 0,
        Insurance,
        Passport,
        Military,
        Other
    }
    public class Identity
    {
        public Identity()
        { }
        public Identity(string identityNo, IdentityType identityType)
        {
            this.IdentityNo = identityNo;
            this.IdentityType = identityType;
        }
        public string IdentityNo { get; set; }
        public IdentityType IdentityType { get; set; }
    }
}



