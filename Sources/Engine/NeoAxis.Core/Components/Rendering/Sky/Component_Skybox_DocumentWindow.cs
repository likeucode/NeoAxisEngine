﻿// Copyright (C) NeoAxis Group Ltd. 8 Copthall, Roseau Valley, 00152 Commonwealth of Dominica.
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using NeoAxis.Widget;

namespace NeoAxis.Editor
{
	public partial class Component_Skybox_DocumentWindow : DocumentWindowWithViewport
	{
		double lastUpdateTime;
		//bool needRecreateInstance;
		Component_Skybox instanceInScene;

		//

		public Component_Skybox_DocumentWindow()
		{
			InitializeComponent();
		}

		public Component_Skybox Skybox
		{
			get { return (Component_Skybox)ObjectOfWindow; }
		}

		protected override void OnLoad( EventArgs e )
		{
			base.OnLoad( e );

			if( Skybox != null )
			{
				var scene = CreateScene( false );

				instanceInScene = (Component_Skybox)Skybox.Clone();
				scene.AddComponent( instanceInScene );

				scene.Enabled = true;

				//if( Document != null )
				//	Document.UndoSystem.ListOfActionsChanged += UndoSystem_ListOfActionsChanged;

				if( ObjectOfWindow != null )
					SelectObjects( new object[] { ObjectOfWindow } );
			}
		}

		//protected override void OnDestroy()
		//{
		//	if( Document != null )
		//		Document.UndoSystem.ListOfActionsChanged -= UndoSystem_ListOfActionsChanged;

		//	base.OnDestroy();
		//}

		protected override void ViewportControl_ViewportCreated( EngineViewportControl sender )
		{
			base.ViewportControl_ViewportCreated( sender );

			ViewportControl.Viewport.AllowRenderScreenLabels = false;
		}

		protected override void Viewport_Tick( Viewport viewport, float delta )
		{
			base.Viewport_Tick( viewport, delta );

			//update
			if( instanceInScene != null && Time.Current > lastUpdateTime + 0.05 )
			//if( instanceInScene != null && needRecreateInstance )// Time.Current > lastUpdateTime + 0.05 )
			{
				instanceInScene.Cubemap = Skybox.Cubemap;
				instanceInScene.Rotation = Skybox.Rotation;
				instanceInScene.Multiplier = Skybox.Multiplier;
				instanceInScene.MultiplierReflection = Skybox.MultiplierReflection;
				instanceInScene.AlwaysUseProcessedCubemap = Skybox.AlwaysUseProcessedCubemap;
				instanceInScene.AllowProcessEnvironmentCubemap = Skybox.AllowProcessEnvironmentCubemap;

				//CreateObject();

				lastUpdateTime = Time.Current;
				//needRecreateInstance = false;
			}
		}

		//protected override void Viewport_UpdateBeforeOutput( Viewport viewport )
		//{
		//	base.Viewport_UpdateBeforeOutput( viewport );

		//	if( Skybox != null && needRecreateInstance )
		//	{
		//		instanceInScene?.Dispose();

		//		instanceInScene = (Component_Skybox)Skybox.Clone();
		//		Scene.AddComponent( instanceInScene );

		//		needRecreateInstance = false;
		//	}
		//}

		//private void UndoSystem_ListOfActionsChanged( object sender, EventArgs e )
		//{
		//	needRecreateInstance = true;
		//}
	}
}
