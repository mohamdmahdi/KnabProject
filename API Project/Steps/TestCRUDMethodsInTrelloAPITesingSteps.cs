using Gherkin;
using Knab_Framework.Map;
using Knab_Framework.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Knab_Framework.Steps
{
    [Binding]
    public class TestCRUDMethodsInTrelloAPITesingSteps
    {
        static BoardMap _board = new BoardMap();
        List<Board> _existingboards;

       [Given(@"I define the request for the API")]
        public void GivenIDefineTheRequestForTheAPI()
        {
            _board.DefineTheRequestToCreateBoard();
        }
        [Given(@"I define Delete request for the API")]
        public void GivenIDefineDeleteRequestForTheAPI()
        {
            _board.DefineTheRequestToDeleteBoard();
        }

        [Given(@"I set the Post method for the API call")]
        public void GivenISetThePostMethodForTheAPICall()
        {
            _board.SetPostMethod();
        }
        [Given(@"I set the board name to (.*)")]
        public void GivenISetTheBoardNameTo(string name)
        {
            _board.SetNewBoardName(name);
        }
        [Given(@"I send the Post request to add new board")]
        public void GivenISendThePostRequestToAddNewBoard()
        {
            _board.ExcuteCreateNewBoard();
        }

        [Then(@"I receive a valid HTTP (.*) code")]
        public void ThenIReceiveAValidHTTPCode(int status)
        {
            Assert.That(_board.GetTheStatusCode, Is.EqualTo(status), "The operation performed successfully");
        }

        [Given(@"I set the Get method for the API call")]
        public void GivenISetTheGetMethodForTheAPICall()
        {
            _board.SetGetMethod();
        }
        [Given(@"I set the Get method to retrieve all boards name, ID and URL")]
        public void GivenISetTheGetMethodToRetrieveAllBoardsNameIDAndURL()
        {
            _board.DefineTheRequestToGetAllBoards();
        }

        [Given(@"I send the Get request to get all boards")]
        public void GivenISendTheGetRequestToGetAllBoards()
        {
            _board.ExecuteGetAllBoardByName();
        }
        
        [Given(@"I checked if the required (.*) board is exists")]
        public void GivenICheckedIfTheRequiredBoardIsExists(string baordname)
        {
            _existingboards= _board.CheckIfTheboardExists(baordname);
        }

        [Given(@"I set the Delete method for the API call")]
        public void GivenISetTheDeleteMethodForTheAPICall()
        {
            _board.SetDeleteMethod();
        }
        [Given(@"I send the Delete reques to delete the board")]
        public void GivenISendTheDeleteRequesToDeleteTheBoard()
        {
            foreach (var board in _existingboards)
            {
                _board.DefineTheRequestToDeleteBoard();
                _board.SetDeletedBoard(board);
                _board.SetDeleteMethod();
                _board.ExecuteDeleteBoard();
            }
            
        }

        [BeforeScenario("DeleteBoard")]
        public static void BeforeDeleteBoard()
        {
            _board.DefineTheRequestToCreateBoard();
            _board.SetGetMethod();
            _board.DefineTheRequestToGetAllBoards();
            _board.ExecuteGetAllBoardByName();
        }


    }
}
