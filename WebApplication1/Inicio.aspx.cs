using MartianRobots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var input = txtInput.Text;
                List<Robot> robots;
                List<List<Command>> commandSequences;
                Input.GetRobotsAndCommandSequences(input, out robots, out commandSequences);

                var commandStation = new CommandStation(robots);
                for (int i = 0; i < commandStation.Robots.Count(); i++)
                    commandStation.TransmitCommandSequence(i, commandSequences[i]);

                var robotReport = Output.GetRobotReport(robots);
                txtOutput.Text = robotReport;
            }
            catch (Exception ex)
            {

                txtOutput.Text = ex.Message;
            }
            
           
        }
    }
}