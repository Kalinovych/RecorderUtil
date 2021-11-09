using System.Reflection;
using UnityEditor;
using UnityEditor.Recorder;
using UnityEngine;

namespace com.kalinovych.unityrecorder {
	public static class RecorderUtil {
		static RecorderWindow GetWindow() {
			return (RecorderWindow)EditorWindow.GetWindow( typeof(RecorderWindow), false, null, false );
		}

		public static void StartRecording() {
			GetWindow().StartRecording();
		}

		public static void StopRecording() {
			GetWindow().StopRecording();
		}

		public static void SetTakeNumber(int number) {
			var field = typeof(RecorderWindow).GetField( "m_SelectedRecorderItem", BindingFlags.Instance | BindingFlags.NonPublic );
			var selectedRecorder = field.GetValue( GetWindow() );
			var settingsProperty = selectedRecorder.GetType().GetProperty( "settings", BindingFlags.Instance | BindingFlags.Public );
			var settings = (RecorderSettings)settingsProperty.GetValue( selectedRecorder );
			settings.Take = number;
			Debug.Log( $"Take number is set to {number}" );
		}
	}
}
