using System;

namespace DhammaTalks.Core.Models
{
    public class Talk
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateRecorded { get; set; }

        public TimeSpan Duration { get; set; }

        public string MediaUrl { get; set; }

        public string MediaMimeType { get; set; }

        public string TeacherName { get; set; }

        public string TeacherId { get; set; }

        public string LocationId { get; set; }

        public string LocationName { get; set; }

        public string GroupId { get; set; }

        public string GroupName { get; set; }

        public string SeriesId { get; set; }

        public string SeriesName { get; set; }
    }
}