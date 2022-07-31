using DepthChartManager.Core.Interfaces.Repositories;
using DepthChartManager.Core.Interfaces.Services;
using DepthChartManager.Core.Services;
using DepthChartManager.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepthChartManager.ConsoleApp
{
    public class Program
    {
        private IServiceProvider _serviceProvider;

        private static void Main(string[] args)
        {
            Task.Run(async () => await new Program().ConfigureServices().Run()).Wait();
        }

        private Program ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddMediatR(typeof(ISportRepository).Assembly);
            services.AddAutoMapper(typeof(ISportRepository).Assembly);
            services.AddSingleton<ISportRepository, SportRepository>();
            services.AddSingleton<IDepthChartService, DepthChartService>();
            _serviceProvider = services.BuildServiceProvider();
            return this;
        }

        private async Task Run()
        {
            var depthChartService = _serviceProvider.GetService<IDepthChartService>();

            // Add league(s)
            var nfl = await depthChartService.AddLeague(1, "NFL"); //NFL
            var mlb = await depthChartService.AddLeague(2, "MLB"); //MLB
            var nhl = await depthChartService.AddLeague(3, "NHL"); //NHL
            var nba = await depthChartService.AddLeague(4, "NBA"); //NBA

            // Add 32 team(s) for NFL league
            var tampaBayBuccaneers = await depthChartService.AddTeam(1, nfl.Id, "Tampa Bay Buccaneers");     //Tampa Bay Buccaneers
            var buffaloBills = await depthChartService.AddTeam(2, nfl.Id, "Buffalo Bills");                  //Buffalo Bills
            var miamiDolphins = await depthChartService.AddTeam(3, nfl.Id, "Miami Dolphins");                //Miami Dolphins
            var newEnglandPatriots = await depthChartService.AddTeam(4, nfl.Id, "New England Patriots");     //New England Patriots
            var newYorkJets = await depthChartService.AddTeam(5, nfl.Id, "New York Jets");                   //New York Jets
            var baltimoreRavens = await depthChartService.AddTeam(6, nfl.Id, "Baltimore Ravens");            //Baltimore Ravens   
            var cincinnatiBengals = await depthChartService.AddTeam(7, nfl.Id, "Cincinnati Bengals");        //Cincinnati Bengals
            var clevelandBrowns = await depthChartService.AddTeam(8, nfl.Id, "Cleveland Browns");            //Cleveland Browns
            var pittsburghSteelers = await depthChartService.AddTeam(9, nfl.Id, "Pittsburgh Steelers");      //Pittsburgh Steelers
            var houstonTexans = await depthChartService.AddTeam(10, nfl.Id, "Houston Texans");               //Houston Texans
            var indianapolisColts = await depthChartService.AddTeam(11, nfl.Id, "Indianapolis Colts");       //Indianapolis Colts
            var jacksonvilleJaguars = await depthChartService.AddTeam(12, nfl.Id, "Jacksonville Jaguars");   //Jacksonville Jaguars
            var tennesseeTitans = await depthChartService.AddTeam(13, nfl.Id, "Tennessee Titans");           //Tennessee Titans     
            var denverBroncos = await depthChartService.AddTeam(14, nfl.Id, "Denver Broncos");               //Denver Broncos 
            var kansasCityChiefs = await depthChartService.AddTeam(15, nfl.Id, "Kansas City Chiefs");        //Kansas City Chiefs 
            var lasVegasRaiders = await depthChartService.AddTeam(16, nfl.Id, "Las Vegas Raiders");          //Las Vegas Raiders 
            var losAngelesChargers = await depthChartService.AddTeam(17, nfl.Id, "Los Angeles Chargers");    //Los Angeles Chargers
            var dallasCowboys = await depthChartService.AddTeam(18, nfl.Id, "Dallas Cowboys");               //Dallas Cowboys 
            var newYorkGiants = await depthChartService.AddTeam(19, nfl.Id, "New York Giants");              //New York Giants 
            var philadelphiaEagles = await depthChartService.AddTeam(20, nfl.Id, "Philadelphia Eagles");     //Philadelphia Eagles 
            var washingtonCommanders = await depthChartService.AddTeam(21, nfl.Id, "Washington Commanders"); //Washington Commanders
            var chicagoBears = await depthChartService.AddTeam(22, nfl.Id, "Chicago Bears");                 //Chicago Bears
            var detroitLions = await depthChartService.AddTeam(23, nfl.Id, "Detroit Lions");                 //Detroit Lions
            var greenBayPackers = await depthChartService.AddTeam(24, nfl.Id, "Green Bay Packers");          //Green Bay Packers
            var minnesotaVikings = await depthChartService.AddTeam(25, nfl.Id, "Minnesota Vikings");         //Minnesota Vikings   
            var atlantaFalcons = await depthChartService.AddTeam(26, nfl.Id, "Atlanta Falcons");             //Atlanta Falcons
            var carolinaPanthers = await depthChartService.AddTeam(27, nfl.Id, "Carolina Panthers");         //Carolina Panthers
            var newOrleansSaints = await depthChartService.AddTeam(28, nfl.Id, "New Orleans Saints");        //New Orleans Saints
            var arizonaCardinals = await depthChartService.AddTeam(29, nfl.Id, "Arizona Cardinals");         //Arizona Cardinals
            var sanFrancisco49ers = await depthChartService.AddTeam(30, nfl.Id, "San Francisco 49ers");      //San Francisco 49ers
            var seattleSeahawks = await depthChartService.AddTeam(31, nfl.Id, "Seattle Seahawks");           //Seattle Seahawks
            var losAngelesRams = await depthChartService.AddTeam(32, nfl.Id, "Los Angeles Rams");            //Los Angeles Rams   

            // Add players for NFL
            var tomBrady = await depthChartService.AddPlayerToDepthChart(1, nfl.Id, tampaBayBuccaneers.Id, "Tom Brady", "LWR", 0);
            var blaineGabbert = await depthChartService.AddPlayerToDepthChart(2, nfl.Id, tampaBayBuccaneers.Id, "Blaine Gabbert", "LWR", 1);
            var kyleTrask = await depthChartService.AddPlayerToDepthChart(3, nfl.Id, tampaBayBuccaneers.Id, "Kyle Trask", "LWR", 2);
            var mikeEvans = await depthChartService.AddPlayerToDepthChart(4, nfl.Id, tampaBayBuccaneers.Id, "Mike Evans", "QB", 0);
            var jaelonDarden = await depthChartService.AddPlayerToDepthChart(5, nfl.Id, tampaBayBuccaneers.Id, "Jaelon Darden", "QB", 1);
            var scottMiller = await depthChartService.AddPlayerToDepthChart(6, nfl.Id, tampaBayBuccaneers.Id, "Scott Miller", "QB", 2);

            // Get backups for NFL
            var tomBradyBkp = await depthChartService.GetBackups(tomBrady.Id, tomBrady.League.Id, tomBrady.Team.Id, tomBrady.Name, tomBrady.Position);

            if (tomBradyBkp != null)
            {
                foreach (var backPlayerPosition in tomBradyBkp)
                {
                    Console.WriteLine($"#{backPlayerPosition.Id} - {backPlayerPosition.Name}");
                }
            }

            //Remove player for NFL
            var removePlayer = await depthChartService.RemovePlayerFromDepthChart(tomBrady.Id, tomBrady.League.Id, tomBrady.Team.Id, tomBrady.Name, tomBrady.Position);
            if (removePlayer != null) Console.WriteLine($"\n#{removePlayer.Id} - {removePlayer.Name}\n");

            // Get full depth chart of NFL
            var tampaBayBuccaneersChart = await depthChartService.GetFullDepthChart(nfl.Id, tampaBayBuccaneers.Id);

            if (tampaBayBuccaneersChart != null)
            {
                foreach (var group in tampaBayBuccaneersChart.GroupBy(p => p.Position))
                {
                    Console.WriteLine($"{group.Key} -{string.Join(",", group.Select(s => $" (#{s.Id}, {s.Name})"))}");
                }
            }

        }
    }
}