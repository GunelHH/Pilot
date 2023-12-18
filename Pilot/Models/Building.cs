using System;
using Pilot.Models.Base;

namespace Pilot.Models
{
	public class Building:BaseEntity
	{
		public NetTopologySuite.Geometries.Geometry Geometry { get; set; }
	}
}

