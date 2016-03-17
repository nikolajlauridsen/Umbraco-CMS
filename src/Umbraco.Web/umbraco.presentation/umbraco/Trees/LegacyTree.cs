﻿using System.Xml;
using umbraco.interfaces;
using Umbraco.Web._Legacy.Utils;

namespace umbraco.cms.presentation.Trees
{

	/// <summary>
	/// A simple wrapper for an ITree that doesn't extend BaseTree. This is used for backwards compatibility with versions previous to 5.
	/// </summary>
	public class LegacyTree : BaseTree
	{

        public LegacyTree(BaseTree tree, string application, XmlTreeNode rootNode)
            : base(application)
        {
            _tree = tree;
            _rootNode = rootNode;

            //we need to re-initialize the class now that we have a root node
            Initialize();
        }

		private BaseTree _tree;
        private XmlTreeNode _rootNode;

        public void SetRootNode(XmlTreeNode rootNode)
        {
            _rootNode = rootNode;
        }

        protected override void CreateRootNode(ref XmlTreeNode rootNode)
        {
            //if the _rootNode is not defined yet, just return an empty one
            if (_rootNode == null)
            {
                NullTree nullTree = new NullTree(this.app);
                _rootNode = XmlTreeNode.CreateRoot(nullTree);
            }                

            rootNode.Menu = _rootNode.Menu;
            rootNode.Text = _rootNode.Text;
            rootNode.Action = _rootNode.Action;
            rootNode.Source = _rootNode.Source;
            rootNode.Icon = _rootNode.Icon;
            rootNode.OpenIcon = _rootNode.OpenIcon;
            rootNode.NodeType = _rootNode.NodeType;
            rootNode.NodeID = _rootNode.NodeID;
        }

        /// <summary>
        /// This will call the normal Render method by passing the converted XmlTree to an XmlDocument.
        /// This is used only for backwards compatibility of converting normal ITrees to BasicTree's
        /// </summary>
        /// <param name="tree"></param>
        public override void Render(ref XmlTree tree)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(tree.ToString(SerializedTreeType.XmlTree));
            Render(ref xDoc);
            tree = SerializableData.Deserialize(xDoc.OuterXml, typeof(XmlTree)) as XmlTree;
			
            foreach (XmlTreeNode node in tree)
            {
                //ensure that the tree type is set for each node
                node.TreeType = this.TreeAlias;
            }
        }

		public override void Render(ref System.Xml.XmlDocument Tree)
		{
            _tree.app = this.m_app;
            _tree.id = this.m_id;
			_tree.Render(ref Tree);
		}

		public override void RenderJS(ref System.Text.StringBuilder Javascript)
		{
            _tree.app = this.m_app;
            _tree.id = this.m_id;
			_tree.RenderJS(ref Javascript);
		}
	}
}
