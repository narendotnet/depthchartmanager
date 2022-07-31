using DepthChartManager.Domain;
using NUnit.Framework;
using System;
using System.Linq;

namespace DepthChartManager.Tests.Domain
{
    public class TeamTests
    {
        [Test]
        public void ShouldThrowExceptionIfTeamNameIsInvalid()
        {
            var league = new League(1, "NFL");
            Assert.Throws<Exception>(() => new Team(1, league, string.Empty));
        }

        [Test]
        public void ShouldPassIfTeamNameIsValid()
        {
            var league = new League(1, "NFL");
            var team = new Team(1, league, "Buffalo Bills");
            Assert.AreEqual("Buffalo Bills", team.Name);
        }

        [Test]
        public void ShouldPassIfTeamIsAdded()
        {
            var league = new League(1, "NFL");

            var addTeam = league.AddTeam(1, "Buffalo Bills");
            Assert.AreEqual("Buffalo Bills", addTeam.Name);
        }

        [Test]
        public void ShouldPassIfGetTeam()
        {
            var league = new League(1, "NFL");

            var addTeam = league.AddTeam(1, "Tampa Bay Buccaneers");
            var getTeam = league.GetTeam(1);

            Assert.AreEqual(addTeam.Name, getTeam.Name);
        }

        [Test]
        public void ShouldThrowExceptionIfTeamPlayerNameIsInvalid()
        {
            var league = new League(1, "NFL");
            var team = new Team(1, league, "Buffalo Bills");
            Assert.Throws<Exception>(() => new Player(1, league, team, string.Empty, "LWR", 0));
        }


        [Test]
        public void ShouldThrowExceptionIfTeamPlayerNameAlreadyExists()
        {
            var league = new League(1, "NFL");
            var team = new Team(1, league, "Buffalo Bills");
            team.AddPlayer(1, "Gill Cam", "LWR", 0);
            Assert.Throws<Exception>(() => team.AddPlayer(1, "Gill Cam", "LWR", 0));
        }

        [Test]
        public void ShouldReturnCorrectPlayerCountInATeam()
        {
            var league = new League(1, "NFL");
            var team = new Team(1, league, "Buffalo Bills");
            team.AddPlayer(1, "Godwin Chris", "LWR", 0);
            team.AddPlayer(2, "Smith Donovan", "LWR", 1);
            Assert.AreEqual(2, team.Players.Count());
        }

        [Test]
        public void ShouldReturnCorrectPlayerPositionInATeam()
        {
            var league = new League(1, "NFL");
            var team = new Team(1, league, "Buffalo Bills");

            var tomBrady = team.AddPlayer(1, "Tom Brady", "LWR", 0);
            var wellsJosh = team.AddPlayer(2, "Wells Josh", "RWR", 1);
            var stuardGrant = team.AddPlayer(3, "Stuard Grant", "SWR", 2);

            Assert.AreEqual("LWR", tomBrady.Position);
            Assert.AreEqual("RWR", wellsJosh.Position);
            Assert.AreEqual("SWR", stuardGrant.Position);
        }

        [Test]
        public void ShouldReturnPlayerBackupsInATeam()
        {
            var league = new League(1, "NFL");
            var team = new Team(1, league, "Buffalo Bills");

            var tomBrady = team.AddPlayer(1, "Tom Brady", "RWR", 0);
            var wellsJosh = team.AddPlayer(2, "Wells Josh", "RWR", 1);
            var stuardGrant = team.AddPlayer(3, "Stuard Grant", "RWR", 2);

            var tomBradyBkp = team.GetBackups(tomBrady.Id, tomBrady.Name, tomBrady.Position);

            Assert.AreEqual(wellsJosh.Id, tomBradyBkp.ElementAtOrDefault(0).Id);
            Assert.AreEqual(stuardGrant.Id, tomBradyBkp.ElementAtOrDefault(1).Id);
        }

        [Test]
        public void ShouldNotReturnRemovedPlayerAsBackupsInATeam()
        {
            var league = new League(1, "NFL");
            var team = new Team(1, league, "Buffalo Bills");

            var tomBrady = team.AddPlayer(1, "Tom Brady", "LWR", 0);
            var wellsJosh = team.AddPlayer(2, "Wells Josh", "LWR", 1);
            var stuardGrant = team.AddPlayer(3, "Stuard Grant", "LWR", 2);

            team.RemovePlayer(wellsJosh.Id, wellsJosh.Name, wellsJosh.Position);
            var tomBradyBkp = team.GetBackups(tomBrady.Id, tomBrady.Name, tomBrady.Position);

            Assert.AreEqual(stuardGrant.Id, tomBradyBkp.ElementAtOrDefault(0).Id);
        }

        [Test]
        public void ShouldRemovePlayerInATeam()
        {
            var league = new League(1, "NFL");
            var team = new Team(1, league, "Buffalo Bills");

            var tomBrady = team.AddPlayer(1, "Tom Brady", "LWR", 0);
            var wellsJosh = team.AddPlayer(2, "Wells Josh", "RWR", 1);
            var stuardGrant = team.AddPlayer(3, "Stuard Grant", "SWR", 2);

            var removeTomBrady = team.RemovePlayer(tomBrady.Id, tomBrady.Name, tomBrady.Position);
            var removeWellsJosh = team.RemovePlayer(wellsJosh.Id, wellsJosh.Name, wellsJosh.Position);
            var removeStuardGrant = team.RemovePlayer(stuardGrant.Id, stuardGrant.Name, stuardGrant.Position);

            Assert.AreEqual(tomBrady.Id, removeTomBrady.Id);
            Assert.AreEqual(wellsJosh.Id, removeWellsJosh.Id);
            Assert.AreEqual(stuardGrant.Id, removeStuardGrant.Id);
        }

        [Test]
        public void ShouldReturnFullDepthInATeam()
        {
            var league = new League(1, "NFL");
            var team = new Team(1, league, "Buffalo Bills");

            var tomBrady = team.AddPlayer(1, "Tom Brady", "LWR", 0);
            var wellsJosh = team.AddPlayer(2, "Wells Josh", "LWR", 1);
            var stuardGrant = team.AddPlayer(3, "Stuard Grant", "LWR", 2);
            var godwinChris = team.AddPlayer(1, "Godwin Chris", "RWR", 0);
            var molchonJohn = team.AddPlayer(2, "Molchon John", "RWR", 1);
            var beisenBen = team.AddPlayer(3, "Beisen Ben", "RWR", 2);
            var cooperChris = team.AddPlayer(1, "Cooper Chris", "SWR", 0);
            var deanJamel = team.AddPlayer(2, "Dean Jamel", "SWR", 1);
            var turnerNolan = team.AddPlayer(3, "Turner Nolan", "SWR", 2);

            var fullDepthChart = team.GetFullDepthChart(league.Id, team.Id);

            Assert.AreEqual(tomBrady.Id, fullDepthChart.ElementAtOrDefault(0).Id);
            Assert.AreEqual(wellsJosh.Id, fullDepthChart.ElementAtOrDefault(1).Id);
            Assert.AreEqual(stuardGrant.Id, fullDepthChart.ElementAtOrDefault(2).Id);
            Assert.AreEqual(godwinChris.Id, fullDepthChart.ElementAtOrDefault(3).Id);
            Assert.AreEqual(molchonJohn.Id, fullDepthChart.ElementAtOrDefault(4).Id);
            Assert.AreEqual(beisenBen.Id, fullDepthChart.ElementAtOrDefault(5).Id);
            Assert.AreEqual(cooperChris.Id, fullDepthChart.ElementAtOrDefault(6).Id);
            Assert.AreEqual(deanJamel.Id, fullDepthChart.ElementAtOrDefault(7).Id);
            Assert.AreEqual(turnerNolan.Id, fullDepthChart.ElementAtOrDefault(8).Id);
        }
    }
}
