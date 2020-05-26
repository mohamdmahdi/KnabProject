using System.Collections.Generic;
using System.Linq;
using Knab_Framework.Model;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Knab_Framework.Map
{
    class BoardMap
    {
        private Board _board;
        private readonly string _createBoardRequestString = "boards/?name={name}&key=2ce8627253bc4d3d6007f3e290a94b4e&token=707536dd406b91ce9711ca6871b90b2830ef7ce7540ed9dc3e5525e85ed1d514";
        private readonly string _getAllBoardRequestString = "members/me/boards?fields=name,url&key=2ce8627253bc4d3d6007f3e290a94b4e&token=707536dd406b91ce9711ca6871b90b2830ef7ce7540ed9dc3e5525e85ed1d514";
        private readonly string _deleteBoardRequestString = "boards/{id}?key=2ce8627253bc4d3d6007f3e290a94b4e&token=707536dd406b91ce9711ca6871b90b2830ef7ce7540ed9dc3e5525e85ed1d514";
        private static string _baseURL = "https://api.trello.com/1/";
        RestClient _client;
        RestRequest _request;
        string _requestString;
        IRestResponse _response;
        JToken _tokens;
        List<Board> _existingboards;

        public BoardMap()
        {
            _board = new Board();
            _client = new RestClient(_baseURL);
            _request = new RestRequest();
            _existingboards = new List<Board>();
        }

        public void SetPostMethod()
        {
            _request.Method = Method.POST;
        }
        public void SetGetMethod()
        {
            _request.Method = Method.GET;
        }
        public void SetDeleteMethod()
        {
            _request.Method = Method.DELETE;
        }

        public void DefineTheRequestToCreateBoard()
        {
            _requestString = _createBoardRequestString;
        }
        public void DefineTheRequestToGetAllBoards()
        {
            _requestString = _getAllBoardRequestString;
            _request.Resource = _requestString;
        }
        public void DefineTheRequestToDeleteBoard()
        {
            _requestString = _deleteBoardRequestString;
        }

        public void SetDeletedBoard(Board board)
        {
            _requestString = _requestString.Replace("{id}", board.ID.ToString());
            _request.Resource = _requestString;
        }
        public void SetNewBoardName(string name)
        {
            _board.Name = name;
            _requestString = _requestString.Replace("{name}", _board.Name);
            _request.Resource = _requestString;
        }
        public void ExcuteCreateNewBoard()
        {
            _response = _client.Execute(_request);
        }
        public void ExecuteGetAllBoardByName()
        {
            _response = _client.Execute(_request);
            _tokens = JToken.Parse(_response.Content);
        }
        public void ExecuteDeleteBoard()
        {
            _response = _client.Execute(_request);
        }
        public int GetTheStatusCode()
        {
            return (int)_response.StatusCode;
        }
        public bool CheckBoardNameExists(string name)
        {
            return _tokens.Any(token => token.Value<string>("name") == name);
        }
        public List<Board> CheckIfTheboardExists(string boardname)
        {
            _request.Method = Method.GET;
            DefineTheRequestToGetAllBoards();
            ExecuteGetAllBoardByName();
            if (CheckBoardNameExists(boardname))
            {
                _existingboards = _tokens.Where(token => token.Value<string>("name") == boardname).Select(token => new Board() { ID = token.Value<string>("id") }).ToList();
            }
            return _existingboards;
        }

    }
}
