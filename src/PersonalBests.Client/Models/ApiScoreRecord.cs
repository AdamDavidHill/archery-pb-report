using System.Text.Json.Serialization;

namespace PersonalBests.Client.Models;

public class ApiScoreRecord
{
    [JsonPropertyName("archer_archived")] public bool? ArcherArchived { get; init; }            //": false
    [JsonPropertyName("archer_id")] public Guid? ArcherId { get; init; }                        //": "609f52b2-d26b-4a97-9c17-2e0ec98dcef3"
    [JsonPropertyName("bow_class")] public string? BowClass { get; init; }                      //": "Barebow"
    [JsonPropertyName("category")] public string? Category { get; init; }                       //": "Men"
    [JsonPropertyName("category_archived")] public bool? CategoryArchived { get; init; }        //": false
    [JsonPropertyName("category_id")] public Guid? CategoryId { get; init; }                    //": "760494c6-375d-440c-b929-fe5b34ef2947"
    [JsonPropertyName("class_archived")] public bool? ClassArchived { get; init; }              //": false
    [JsonPropertyName("class_id")] public Guid? ClassId { get; init; }                          //": "f7c73f07-a466-4cb4-81e7-c957c4aab19e"
    [JsonPropertyName("classification")] public string? Classification { get; init; }           //": ""
    [JsonPropertyName("date_shot")] public DateTime? DateShot { get; init; }                    //": "2024-03-22T00:00:00"
    [JsonPropertyName("golds")] public int? Golds { get; init; }                                //": 14
    [JsonPropertyName("handicap")] public int? Handicap { get; init; }                          //": -1
    [JsonPropertyName("hits")] public int? Hits { get; init; }                                  //": 60
    [JsonPropertyName("location")] public string? Location { get; init; }                       //": "A Place"
    [JsonPropertyName("name")] public string? Name { get; init; }                               //": "John Doe"
    [JsonPropertyName("qualifying")] public bool? Qualifying { get; init; }                     //": false
    [JsonPropertyName("record_id")] public Guid? RecordId { get; init; }                        //": "37418140-a785-48a3-bb92-8e704a50c583"
    [JsonPropertyName("record_status")] public bool? RecordStatus { get; init; }                //": false
    [JsonPropertyName("round")] public string? Round { get; init; }                             //": "Portsmouth"
    [JsonPropertyName("round_archived")] public bool? RoundArchived { get; init; }              //": false
    [JsonPropertyName("round_id")] public Guid? RoundId { get; init; }                          //": "7ff99953-7430-4620-af8e-a26bcf5769e9"
    [JsonPropertyName("score")] public int? Score { get; init; }                                //": 528
    [JsonPropertyName("scoresheets")] public List<string>? Scoresheets { get; init; } = new();  //": []
    [JsonPropertyName("season")] public string? Season { get; init; }                           //": "Indoor 2023/2024"
    [JsonPropertyName("season_archive")] public bool? SeasonArchive { get; init; }              //": false
    [JsonPropertyName("season_id")] public Guid? SeasonId { get; init; }                        //": "22335241-be3c-4411-97b1-6988bc15f6a8"
    [JsonPropertyName("status")] public string? Status { get; init; }                           //": null
    [JsonPropertyName("tens")] public int? Tens { get; init; }                                  //": 0
    [JsonPropertyName("type_id")] public Guid? TypeId { get; init; }                            //": "5ca2beea-0c8d-4e3a-8218-379677663022"
    [JsonPropertyName("user_1")] public string? User1 { get; init; }                            //": ""
    [JsonPropertyName("user_2")] public string? User2 { get; init; }                            //": "
}
