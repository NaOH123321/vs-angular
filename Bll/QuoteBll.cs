using System.Collections.Generic;
using vstaskmgr.Model;

namespace vstaskmgr.Bll
{
    public class QuoteBll
    {
        private List<Quote> GetQuotesList()
        {
            List<Quote> quoteArray = new List<Quote>();
            Quote quote1 = new Quote(
                0,
                "我突然就觉得自己像个华丽的木偶,演尽了所有的悲欢离合,可是背上总是有无数闪亮的银色丝线,操纵我哪怕一举手一投足。",
                "I suddenly feel myself like a doll,acting all kinds of joys and sorrows.There are lots of shining silvery thread on my back,controlling all my action.",
                "/assets/img/quotes/0.jpg"
            );
            quoteArray.Add(quote1);
            Quote quote2 = new Quote(
                1,
                "被击垮通常只是暂时的，但如果你放弃的话，就会使它成为永恒。（Marilyn vos Savant）",
               "Being defeated is often a temporary condition. Giving up is what makes it permanent.",
                "/assets/img/quotes/1.jpg"
            );
            quoteArray.Add(quote2);
            Quote quote3 = new Quote(
                2,
                "不要只因一次挫败，就放弃你原来决心想达到的梦想。（莎士比亚）",
               "Do not, for one repulse, forgo the purpose that you resolved to effect.",
               "/assets/img/quotes/2.jpg"
            );
            quoteArray.Add(quote3);

            return quoteArray;
        }
        public List<Quote> GetQuoteList()
        {
            List<Quote> quoteArray = GetQuotesList();
            return quoteArray;
        }

    }
}
