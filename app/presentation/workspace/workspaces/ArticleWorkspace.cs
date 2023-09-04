using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iwbe.presentation.workspace.workspaces
{
    internal class ArticleWorkspace : IWorkspace
    {
        public Guid Id => Guid.Parse("{12F446EC-F9BD-4BE9-9FC1-BA057A57390B}");

        public string Name => "Articles";

        public string ResourceUrlView => "presentation/views/workspace/article/ArticleWorkspace.tscn";

        public string ResourceUrlIcon => "presentation/img/doc-01.svg";
    }
}
