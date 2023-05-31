﻿using Microsoft.EntityFrameworkCore;
using ProjectHiveAPI.Models;

namespace ProjectHiveAPI.DataBase
{
    public class ProjectHiveContext : DbContext
    {
        public ProjectHiveContext(DbContextOptions<ProjectHiveContext> options) : base(options) { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<MarkTask> MarkTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SubscriptionPlan> Plans { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
    }
}
