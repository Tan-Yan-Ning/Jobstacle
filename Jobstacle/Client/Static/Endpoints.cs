using Jobstacle.Shared.Domain;

namespace Jobstacle.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

		public static readonly string CompaniesEndpoint = $"{Prefix}/companies";
		public static readonly string CoursesEndpoint = $"{Prefix}/courses";
		public static readonly string CourseRegistrationsEndpoint = $"{Prefix}/courseregistrations";
		public static readonly string JobApplicationsEndpoint =$"{Prefix}/jobapplications";
		public static readonly string JobSeekersEndpoint =$"{Prefix}/jobseekers";
		public static readonly string StaffsEndpoint = $"{Prefix}/staffs";
		public static readonly string OrganizersEndpoint = $"{Prefix}/organizers";
		public static readonly string JobsEndpoint =$"{Prefix}/jobs";
    }
}
