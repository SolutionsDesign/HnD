using System.Collections;
using System.Collections.Generic;

namespace SD.HnD.Gui.Models.Admin
{
	/// <summary>
	/// Generic bucket class for data that is to be send to the jsGrid. Instances are serialized to json.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class JsGridData<T>
	{
		public IEnumerable<T> data { get; set; }
		public int itemsCount { get; set; } 
	}
}