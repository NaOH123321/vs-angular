namespace vstaskmgr.Model
{
    public class Quote
    {
        public Quote()
        { }
        public Quote(int id, string cn, string en, string pic)
        {
            this.Id = id;
            this.Cn = cn;
            this.En = en;
            this.Pic = pic;
        }
        public int Id { get; set; }
        public string Cn { get; set; }
        public string En { get; set; }
        public string Pic { get; set; }
    }
}
