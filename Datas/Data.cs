using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vstaskmgr.Datas
{
    public class Data
    {
        private void AddQuote()
        {
            var document1 = new BsonDocument
            {
                { "Cn",   "我突然就觉得自己像个华丽的木偶,演尽了所有的悲欢离合,可是背上总是有无数闪亮的银色丝线,操纵我哪怕一举手一投足。" },
                { "En",    "I suddenly feel myself like a doll,acting all kinds of joys and sorrows.There are lots of shining silvery thread on my back,controlling all my action."},
                { "Pic",  "/assets/img/quotes/0.jpg" }
            };

            var document2 = new BsonDocument
            {
                { "Cn",    "被击垮通常只是暂时的，但如果你放弃的话，就会使它成为永恒。（Marilyn vos Savant）" },
                { "En",  "Being defeated is often a temporary condition. Giving up is what makes it permanent."},
                { "Pic",  "/assets/img/quotes/1.jpg" }
            };


            var document3 = new BsonDocument
            {
                { "Cn",  "不要只因一次挫败，就放弃你原来决心想达到的梦想。（莎士比亚）" },
                { "En",   "Do not, for one repulse, forgo the purpose that you resolved to effect."},
                { "Pic",  "/assets/img/quotes/2.jpg" }
            };
        }

    }
}
