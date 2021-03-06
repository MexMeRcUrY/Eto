using System;
using System.Collections;
using System.Collections.Generic;

namespace Eto.Forms
{
	[Obsolete("Use Command and menu/toolbar apis directly instead")]
	public class GenerateActionArgs : EventArgs
	{
		#region Members
		
		readonly ActionCollection actions;
		readonly ActionItemCollection menu;
		readonly ActionItemCollection toolBar;
		readonly Dictionary<object, object> arguments = new Dictionary<object, object>();
		
		#endregion
		
		#region Properties

		public Generator Generator
		{
			get { return actions.Generator; }
		}
		
		public ActionCollection Actions
		{
			get { return actions; }
		}
		
		public ActionItemCollection Menu
		{
			get { return menu; }
		}
		
		public ActionItemCollection ToolBar
		{
			get { return toolBar; }
		}

		public Dictionary<object, object> Arguments
		{
			get { return arguments; }
		}
		
		#endregion

		public GenerateActionArgs()
			: this((Generator)null)
		{
		}

		public GenerateActionArgs(Generator generator)
			: this(generator, null)
		{
		}
		
		public GenerateActionArgs(Control control)
			: this(control.Generator, control)
		{
		}
		
		public GenerateActionArgs(Generator g, Control control)
		{
			this.actions = new ActionCollection(g, control);
			this.menu = new ActionItemCollection(actions);
			this.toolBar = new ActionItemCollection(actions);
		}
		
		public GenerateActionArgs(ActionCollection actions, ActionItemCollection menu, ActionItemCollection toolBar)
		{
			this.actions = actions;
			this.menu = menu;
			this.toolBar = toolBar;
		}

		public void CopyArguments(GenerateActionArgs args)
		{
			foreach (var de in args.arguments)
			{
				arguments[de.Key] = de.Value;
			}
		}
		
		public void Merge(GenerateActionArgs args)
		{
			toolBar.Merge(args.toolBar);
			menu.Merge(args.Menu);
		}
		
		public object GetArgument(object key, object defaultValue)
		{
			return !arguments.ContainsKey(key) ? defaultValue : arguments[key];
		}

		public void Clear()
		{
			actions.Clear();
			menu.Clear();
			toolBar.Clear();
		}
	}
}
