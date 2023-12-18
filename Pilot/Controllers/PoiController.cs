using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Algorithm;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.Index.HPRtree;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using Pilot.DAL;
using Pilot.Models;

namespace Pilot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoiController : ControllerBase
    {

        [HttpGet]
        public IActionResult SetPoiJsonToDataBase()
        {
            string PoiDatas = "/Users/gunelhesenova/Desktop/PilotMina/data/poi.geojson";

           
            if (System.IO.File.Exists(PoiDatas))
            {
               var deserializedPoi = JsonConvert.DeserializeObject<Poi>(System.IO.File.ReadAllText(PoiDatas));

                try
                {
                    string connectionString = "Host=localhost;Database=Pilot;Username=postgres;Password=gunel6864";

                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();

                        using (NpgsqlCommand command = new NpgsqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandType = CommandType.Text;
                            for (int i=0; i < deserializedPoi.features.Count;i++)
                            {
                                command.CommandText = $"INSERT INTO public.\"POI\"(type,featureType,featureGeometryType) VALUES (@param1,@param2,@param3)";
                                command.Parameters.AddWithValue("@param1", deserializedPoi.type);
                                command.Parameters.AddWithValue("@param2", deserializedPoi.features[i].type);
                                command.Parameters.AddWithValue("@param3", deserializedPoi.features[i].geometry.type);
                               
                                //command.Parameters.AddWithValue("@param1", deserializedPoi.type);
                                //command.Parameters.AddWithValue("@param2", feature.type);
                                //command.Parameters.AddWithValue("@param3", feature.geometry.type);
                                //foreach (var item in feature.geometry.coordinates)
                                //{
                                //    command.Parameters.AddWithValue("@param4", item);
                                //}


                                command.ExecuteNonQuery();
                            }
                    }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

            }


            return Ok();
        }
    }
}
