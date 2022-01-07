using AdvancedCalculator.Nodes;
using System;

namespace AdvancedCalculator.Tokens
{
    public abstract class OneArgumentFunctionTokenBase<TNode> : Token
        where TNode : Node, ICollectionNode, new()
    {
        protected Token[] _param;

        public OneArgumentFunctionTokenBase(Token[] parameter)
        {
            if (parameter == null || parameter.Length == 0) throw new Exception("Empty argument");
            this._param = parameter;
        }

        public override Node GetNode()
        {
            var ret = new TNode();
            ret[0] = NodeBuilder.BuildTree(this._param);
            return ret;
        }
    }
}
