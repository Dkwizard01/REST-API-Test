using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TasksController : ControllerBase
    {
        string[] tasks = ["External ID", "Use backend API Microservice", "CosmosDB", "Call direct method", "Return response"];
        
       
        [HttpGet]
        public string ApiTasks()
        {
            return String.Join(",", tasks);
            
        }
        [HttpDelete("{numElements}")]
        public string DeleteTasks(int numElements)
        {
            return String.Join(",", tasks, numElements, tasks.Length - numElements);
        }
        [HttpPut("{length}, {position}, {add}")] 
        public string Addtasks(int length, int position, string add)
        {
            string[] nTasks = new string[length];
            Array.Copy(tasks, nTasks, tasks.Length);
            nTasks[position] = add;
            return String.Join(",", nTasks);
        }
        [HttpPost("{length}, {position}, {add}")]

        public string NewArray(int length, int position = 0, string add = " ")
        {
            string[] nArray = new string[length];
            nArray[position] = add;
            return String.Join(",", nArray);
        }
    }
}