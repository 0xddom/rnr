using System;
namespace RnR.Consoles
{
	public class MenuItem
	{
		public MenuItem (int id, string entry, bool selected)
		{
			Id = id;
			Entry = entry;
			Selected = selected;
		}

		public int Id { get; set; }
		public string Entry { get; set; }
		public bool Selected { get; set; }
	}
}
