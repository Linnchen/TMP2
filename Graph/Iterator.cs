using System;
using System.Collections.Generic;
using System.Text;

namespace _15012020_graph
{
    public abstract class Iterator
    {
       public abstract object First();
       public abstract object Next();
       public abstract bool IsDone();
       public abstract object Current();
       public abstract void Reset();
    }

    public class NodeIterator : Iterator
    {
        private readonly Node Node;
        private int Index;

        public NodeIterator(Node pNode)
        {
            Node = pNode;
            Index = 0;
        }

        public override object First()
        {
            return Node[0] as Node;
        }

        public override object Next()
        {
            Node result = null;

            if (Index <= Node.Count - 1)
            {
                result = Node[Index];

                Index += 1;
            }
            if (Index == Node.Count - 1)
            {
                Node.AllChildrenVisitedEvent();
            }

            return (result as Node);
        }

        public override void Reset()
        {
            Index = 0;
        }


        public override bool IsDone()
        {
            return Index > Node.Count - 1;
        }

        public override object Current()
        {
            return Node[Index];
        }
    }

}
