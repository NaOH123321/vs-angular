using System.Collections.Generic;
using vstaskmgr.Model;

namespace vstaskmgr.Bll
{
    public class ProjectBll
    {
        private List<Project> GetProjectsList()
        {
            List<Project> projectArray = new List<Project>();
            Project project1 = new Project(
               "1",
                "企业协作平台",
                "assets/img/covers/0.jpg",
                "这是一个企业内部项目"
            );
            project1.Members = new string[] { "BkkDvwee-", "3", "4" };
            projectArray.Add(project1);

            Project project2 = new Project(
                "2",
                "自动化测试项目",
                 "assets/img/covers/1.jpg",
                "这是一个企业内部项目"
            );
            project2.Members = new string[] { "BkkDvwee-", "4", "37489e0c-df34-c261-71c4-ce75357e3035" };
            projectArray.Add(project2);

            return projectArray;
        }
        public List<Project> GetProjectList()
        {
            List<Project> projectArray = GetProjectsList();
            return projectArray;
        }

    }
}
