using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebAPI.Containers.Models
{
    /// <summary>
    /// Defines the <see cref="Answer" /> class is used for sending a JSON message in a web API to an end-user. 
    /// The answer can be a success or a failure.
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Gets or sets a <see cref="bool" /> indicating whether <see cref="IsASuccess" /> is true or false. 
        /// <see cref="IsASuccess" /> store if the request was abandoned or a success.
        /// True is a success, and false is a request that was not fulfilled 
        /// and can be created by an error or a bad request by an end-user.
        /// </summary>
        public bool IsASuccess { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="object" />.
        /// It can be a JSON <see cref="object" /> answer to the end-user, 
        /// or it can be a <see cref="string" />/JSON <see cref="object" /> to tell why the request failed.
        /// </summary>
        public object Json { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Answer"/> class.
        /// </summary>
        public Answer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Answer"/> class.
        /// </summary>
        /// <param name="isASuccess">The isASuccess<see cref="bool"/>.</param>
        /// <param name="json">The json<see cref="object"/>.</param>
        public Answer(bool isASuccess, object json)
        {
            this.IsASuccess = isASuccess;
            this.Json = json;
        }

        /// <summary>
        /// Use to tell why a request failed and use an <see cref="Exception"/> to tell why.
        /// </summary>
        /// <param name="ex">The ex<see cref="Exception"/>.</param>
        /// <returns>The <see cref="Answer"/> holds a failed request.</returns>
        public static Answer Error(Exception ex)
        {
            Answer answer = new Answer();

            answer.IsASuccess = false;
            answer.Json = ex;

            return answer;
        }
        /// <summary>
        /// Use to tell why a request failed and use an <see cref="string"/> to tell why.
        /// </summary>
        /// <param name="text">The text<see cref="string"/>.</param>
        /// <returns>The <see cref="Answer"/> holds a failed request.</returns>
        public static Answer Error(string text)
        {
            Answer answer = new Answer();

            answer.IsASuccess = false;
            answer.Json = text;

            return answer;
        }
        
        /// <summary>
        /// Use to tell why a request was successful and use an <see cref="string"/> to tell why 
        /// or don't it can be null if no answer is needed to be told to the end-user.. 
        /// </summary>
        /// <param name="text">The text<see cref="string"/>.</param>
        /// <returns>The <see cref="Answer"/> holds a successful request.</returns>
        public static Answer Complete(string text)
        {
            Answer answer = new Answer();

            answer.IsASuccess = true;
            answer.Json = text;

            return answer;
        }

        /// <summary>
        /// Use to tell a request was successful and give end-users what they asked for in JSON <see cref="object"/>. 
        /// JSON <see cref="object"/> can be null if no answer is needed to be told to the end-user. 
        /// </summary>
        /// <param name="json">The json<see cref="Object"/>.</param>
        /// <returns>The <see cref="Answer"/> holds a successful request.</returns>
        public static Answer Complete(object json)
        {
            Answer answer = new Answer();

            answer.IsASuccess = true;
            answer.Json = json;

            return answer;
        }
        /// <summary>
        /// Use to tell why a request was successful and use an <see cref="string"/> to tell why 
        /// or don't it can be null if no answer is needed to be told to the end-user.. 
        /// </summary>
        /// <returns>The <see cref="Answer"/> holds a successful request.</returns>
        public static Answer Complete()
        {
            Answer answer = new Answer();

            answer.IsASuccess = true;
            answer.Json = null;

            return answer;
        }
    }
}