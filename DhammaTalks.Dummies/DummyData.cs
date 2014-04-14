using System;
using System.Collections.Generic;
using DhammaTalks.Core.Models;

namespace DhammaTalks.Dummies
{
    public static class DummyData
    {
        public static List<Talk> Talks = new List<Talk>()
            {
                new Talk()
                {
                    Id = "SampleTalk1",
                    Title = "A Title 1",
                    Description = "A first sample talk.",
                    TeacherId = "SampleTeacher1",
                    TeacherName = "Sample Teacher 1",
                    DateRecorded = DateTime.Today.AddDays(-1),
                    MediaUrl = "http://www.dharmaseed.org/teacher/312/talk/22758/20140330-Rick_Hanson-SR-equanimity_daylong_afternoon_session_pt_4_of_5.mp3",
                    MediaMimeType = "audio/mpeg",
                    Duration = new TimeSpan(0, 11, 33)
                },
                new Talk()
                {
                    Id = "SampleTalk2",
                    Title = "A Title 2",
                    Description = "A second sample talk.",
                    TeacherId = "SampleTeacher1",
                    TeacherName = "Sample Teacher 1",
                    DateRecorded = DateTime.Today.AddDays(-2),
                    MediaUrl = "http://www.dharmaseed.org/teacher/312/talk/22753/20140330-Rick_Hanson-SR-equanimity_daylong_morning_session_pt_9_of_9.mp3",
                    MediaMimeType = "audio/mpeg",
                    Duration = new TimeSpan(0, 4, 1)
                }
            };

        public static List<Teacher> Teachers = new List<Teacher>()
            {
                new Teacher()
                    {
                        Id = "SampleTeacher1",
                        Name = "Sample Teacher 1",
                        Description = "The first sample teacher."
                    }
            }; 
    }
}