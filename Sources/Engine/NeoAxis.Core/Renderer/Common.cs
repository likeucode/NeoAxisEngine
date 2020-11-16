// Copyright (C) NeoAxis Group Ltd. 8 Copthall, Roseau Valley, 00152 Commonwealth of Dominica.
using System;

namespace NeoAxis
{
	/// <summary>Filtering options for textures / mipmaps.</summary>
	public enum FilterOption
	{
		/// <summary>No filtering, used for <b>FilterType.Mip</b> to turn off mipmapping.</summary>
		None,// = Ogre::FO_NONE,
		/// <summary>Use the closest pixel.</summary>
		Point,// = Ogre::FO_POINT,
		/// <summary>Average of a 2x2 pixel area, denotes bilinear for <b>FilterType.Min</b> and <b>FilterType.Mag</b>, trilinear for <b>FilterType.Mip</b>.</summary>
		Linear,// = Ogre::FO_LINEAR,
		/// <summary>Similar to FO_LINEAR, but compensates for the angle of the texture plane.</summary>
		Anisotropic,// = Ogre::FO_ANISOTROPIC
	}

	/// <summary>Defines the frame buffer types.</summary>
	[Flags]
	public enum FrameBufferTypes
	{
		/// <summary>The color buffer.</summary>
		Color = 0x1,//Ogre::FBT_COLOUR,
		/// <summary>The depth buffer.</summary>
		Depth = 0x2,//Ogre::FBT_DEPTH,
		/// <summary>The stencil buffer.</summary>
		Stencil = 0x4,//Ogre::FBT_STENCIL,

		All = Color | Depth | Stencil,
	}

	/// <summary>
	/// The rendering operation type to perform.
	/// </summary>
	public enum RenderOperationType
	{
		/// <summary>A list of points, 1 vertex per point.</summary>
		PointList = 1,//Ogre::RenderOperation::OT_POINT_LIST,
		/// <summary>A list of lines, 2 vertices per line.</summary>
		LineList = 2,//Ogre::RenderOperation::OT_LINE_LIST,
		/// <summary>A strip of connected lines, 1 vertex per line plus 1 start vertex.</summary>
		LineStrip = 3,//Ogre::RenderOperation::OT_LINE_STRIP,
		/// <summary>A list of triangles, 3 vertices per triangle.</summary>
		TriangleList = 4,//Ogre::RenderOperation::OT_TRIANGLE_LIST,
		/// <summary>A strip of triangles, 3 vertices for the first triangle, and 1 per triangle after that.</summary>
		TriangleStrip = 5,//Ogre::RenderOperation::OT_TRIANGLE_STRIP,
						  //				  /// <summary>A fan of triangles, 3 vertices for the first triangle, and 1 per triangle after that.</summary>
						  //TriangleFan = 6,//Ogre::RenderOperation::OT_TRIANGLE_FAN
	}

	/// <summary>
	/// Blend factors, which modulate values for the pixel shader and render target.
	/// </summary>
	public enum SceneBlendFactor
	{
		One,// = Ogre::SBF_ONE,
		Zero,// = Ogre::SBF_ZERO,
		DestinationColor,// = Ogre::SBF_DEST_COLOUR,
		SourceColor,// = Ogre::SBF_SOURCE_COLOUR,
		OneMinusDestColor,// = Ogre::SBF_ONE_MINUS_DEST_COLOUR,
		OneMinusSourceColor,// = Ogre::SBF_ONE_MINUS_SOURCE_COLOUR,
		DestinationAlpha,// = Ogre::SBF_DEST_ALPHA,
		SourceAlpha,// = Ogre::SBF_SOURCE_ALPHA,
		OneMinusDestinationAlpha,// = Ogre::SBF_ONE_MINUS_DEST_ALPHA,
		OneMinusSourceAlpha,// = Ogre::SBF_ONE_MINUS_SOURCE_ALPHA
	}

	/// <summary>
	/// Hardware culling modes based on vertex winding.
	/// This setting applies to how the hardware API culls triangles it is sent.
	/// </summary>
	public enum CullingMode
	{
		/// <summary>
		/// Hardware never culls triangles and renders everything it receives.
		/// </summary>
		None = 1,//Ogre::CULL_NONE,

		/// <summary>
		/// Hardware culls triangles whose vertices are listed clockwise in the view (default).
		/// </summary>
		Clockwise = 2,//Ogre::CULL_CLOCKWISE,

		/// <summary>
		/// Hardware culls triangles whose vertices are listed anticlockwise in the view.
		/// </summary>
		Anticlockwise = 3,//Ogre::CULL_ANTICLOCKWISE,
	}

	/// <summary>
	/// Comparison functions used for the depth/stencil buffer operations and others.
	/// </summary>
	public enum CompareFunction
	{
		AlwaysFail,// = Ogre::CMPF_ALWAYS_FAIL,
		AlwaysPass,// = Ogre::CMPF_ALWAYS_PASS,
		Less,// = Ogre::CMPF_LESS,
		LessEqual,// = Ogre::CMPF_LESS_EQUAL,
		Equal,// = Ogre::CMPF_EQUAL,
		NotEqual,// = Ogre::CMPF_NOT_EQUAL,
		GreaterEqual,// = Ogre::CMPF_GREATER_EQUAL,
		Greater,// = Ogre::CMPF_GREATER
	}

	/// <summary>
	/// Enumerates the types of programs which can run on the GPU.
	/// </summary>
	public enum GpuProgramType
	{
		Vertex,
		Fragment,
		Compute,

		Count,
	}

	public enum RenderSystemEvent
	{
		DeviceLost,
		DeviceRestored,
	}

	/// <summary>
	/// Texture addressing modes.
	/// </summary>
	[Flags]
	public enum TextureAddressingMode
	{
		WrapU = 1,
		WrapV = 2,
		WrapW = 4,
		/// <summary>Texture wraps at values outside 0.0-1.0.</summary>
		Wrap = WrapU | WrapV | WrapW,

		MirrorU = 8,
		MirrorV = 16,
		MirrorW = 32,
		/// <summary>Texture mirrors (flips) at joins over 1.0.</summary>
		Mirror = MirrorU | MirrorV | MirrorW,

		ClampU = 64,
		ClampV = 128,
		ClampW = 256,
		/// <summary>Texture clamps at 1.0.</summary>
		Clamp = ClampU | ClampV | ClampW,

		BorderU = 512,
		BorderV = 1024,
		BorderW = 2048,
		/// <summary>Texture coordinates outside the range [0.0, 1.0] are set to the border colour.</summary>
		Border = BorderU | BorderV | BorderW,
	}

	///// <summary>
	///// Texture addressing modes.
	///// </summary>
	//public enum TextureAddressingMode
	//{
	//	/// <summary>Texture wraps at values over 1.0.</summary>
	//	Wrap,// = Ogre::TextureUnitState::TAM_WRAP,
	//		 /// <summary>Texture mirrors (flips) at joins over 1.0.</summary>
	//	Mirror,// = Ogre::TextureUnitState::TAM_MIRROR,
	//		   /// <summary>Texture clamps at 1.0.</summary>
	//	Clamp,// = Ogre::TextureUnitState::TAM_CLAMP,
	//		  /// <summary>Texture coordinates outside the range [0.0, 1.0] are set to the border colour.</summary>
	//	Border,// = Ogre::TextureUnitState::TAM_BORDER
	//}

	//!!!!���?
	public enum GetRenderSceneDataMode
	{
		InsideFrustum,
		ShadowCasterOutsideFrustum,
	}

	[Flags]
	public enum GpuBufferFlags
	{
		Dynamic = 1,
		ComputeWrite = 2,
	}

	public enum UnwrappedUVEnum
	{
		None,
		TextureCoordinate0,
		TextureCoordinate1,
		TextureCoordinate2,
		TextureCoordinate3,
	}
}
