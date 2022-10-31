// Copyright (c) 2022 hibzz.games
//
// Author:       Hibnu Hishath (sliptrixx)
// Description:  A tool that takes a high quality screenshot of the game view 
//               directly from the editor
//
// License ID:   N/A
// License:      This script can only be used on projects made by Hibzz Games
//               or on projects that have a valid license ID. To request a
//               custom license and a license ID, please send an email to
//               support@hibzz.games with details about the project.
// 
//               THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY
//               KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//               WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//               PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//               COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//               LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//               ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
//               USE OR OTHER DEALINGS IN THE SOFTWARE.


#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using UnityEditor.Toolbars;
using UnityEditor.Overlays;
using System;
using System.IO;

namespace Hibzz.Tools
{
	[EditorToolbarElement(id, typeof(SceneView))]
	class CaptureScreenshot : EditorToolbarButton, IAccessContainerWindow
	{
		// the id to populate the toolbar element
		public const string id = "CustomToolbar/CaptureScreenshot";

		// IAccessContainerWindow provides a way for toolbar elements to access the `EditorWindow` in which they exist
		public EditorWindow containerWindow { get; set; }

		// public default constructor
		public CaptureScreenshot()
		{
			icon = EditorGUIUtility.IconContent("d_FrameCapture").image as Texture2D;

			tooltip = "Capture Screenshot";
			clicked += OnClick;
		}

		private void OnClick()
		{
			string filename = $"{Directory.GetCurrentDirectory()}\\Screenshots\\{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}.png";
			ScreenCapture.CaptureScreenshot(filename);
			Debug.Log($"Save screenshot to '{filename}'");
		}
	}

	[Overlay(typeof(SceneView), "Custom Tools")]
	public class CustomToolbar : ToolbarOverlay
	{
		CustomToolbar() : base(CaptureScreenshot.id) { }
	}
}

#endif
