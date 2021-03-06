//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PanoramaJXNU.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserInfo
    {
        public UserInfo()
        {
            this.Collect = new HashSet<Collect>();
            this.Comment = new HashSet<Comment>();
            this.Comment1 = new HashSet<Comment>();
            this.ReplyPraiseRecord = new HashSet<ReplyPraiseRecord>();
            this.Topic = new HashSet<Topic>();
            this.TopicPraiseRecord = new HashSet<TopicPraiseRecord>();
            this.PanoCollect = new HashSet<PanoCollect>();
            this.PanoPraiseRecord = new HashSet<PanoPraiseRecord>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PWord { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string HeadImg { get; set; }
        public System.DateTime RegTime { get; set; }
        public System.DateTime DataLastLogin { get; set; }
        public int TopicCount { get; set; }
        public byte Status { get; set; }
        public byte DelFlag { get; set; }
        public string Signature { get; set; }
        public string City { get; set; }
    
        public virtual ICollection<Collect> Collect { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Comment> Comment1 { get; set; }
        public virtual ICollection<ReplyPraiseRecord> ReplyPraiseRecord { get; set; }
        public virtual ICollection<Topic> Topic { get; set; }
        public virtual ICollection<TopicPraiseRecord> TopicPraiseRecord { get; set; }
        public virtual ICollection<PanoCollect> PanoCollect { get; set; }
        public virtual ICollection<PanoPraiseRecord> PanoPraiseRecord { get; set; }
    }
}
