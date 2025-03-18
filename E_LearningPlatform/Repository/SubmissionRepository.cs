using Dapper;
using E_LearningPlatform.Models;
//using E_LearningPlatform.Exceptions;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System;

namespace E_LearningPlatform.Repository
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly string _connectionString;

        public SubmissionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task AddSubmissionAsync(Submission submission)
        {
            try
            {
                if (submission.Score > 100)
                {
                    throw new InvalidScoreException("Score can't exceed 100.");
                }
                using (var dbConnection = Connection)
                {
                    string sql = @"
                INSERT INTO Submissions (AssessmentId, StudentId, Score)
                VALUES (@AssessmentId, @StudentId, @Score)";

                    await dbConnection.ExecuteAsync(sql, submission);
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Failed to add submission.", ex);
            }
        }

        public async Task DeleteSubmissionAsync(int id)
        {
            try
            {
                using (var dbConnection = Connection)
                {
                    string checkSql = "SELECT COUNT(1) FROM Submissions WHERE SubmissionId = @Id";
                    var exists = await dbConnection.ExecuteScalarAsync<bool>(checkSql, new { Id = id });

                    if (!exists)
                    {
                        throw new SubmissionNotFoundException("Submission not found or can't delete.");
                    }

                    string deleteSql = "DELETE FROM Submissions WHERE SubmissionId = @Id";
                    await dbConnection.ExecuteAsync(deleteSql, new { Id = id });
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Failed to delete submission.", ex);
            }
        }

        public async Task<IEnumerable<Submission>> GetAllSubmissionsAsync()
        {
            try
            {
                using (var dbConnection = Connection)
                {
                    string sql = "SELECT * FROM Submissions";
                    return await dbConnection.QueryAsync<Submission>(sql);
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Failed to retrieve submissions.", ex);
            }
        }

        public async Task<Submission> GetSubmissionByIdAsync(int id)
        {
            try
            {
                using (var dbConnection = Connection)
                {
                    string sql = "SELECT * FROM Submissions WHERE SubmissionId = @Id";
                    var submission = await dbConnection.QueryFirstOrDefaultAsync<Submission>(sql, new { Id = id });
                    if (submission == null)
                    {
                        throw new NotFoundException("Submission not found.");
                    }
                    return submission;
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Failed to retrieve submission.", ex);
            }
        }

        public async Task UpdateSubmissionAsync(Submission submission)
        {
            try
            {
                using (var dbConnection = Connection)
                {
                    string checkSql = "SELECT COUNT(1) FROM Submissions WHERE SubmissionId = @SubmissionId";
                    var exists = await dbConnection.ExecuteScalarAsync<bool>(checkSql, new { submission.SubmissionId });

                    if (!exists)
                    {
                        throw new SubmissionNotFoundException("Submission not found or can't update.");
                    }

                    string updateSql = "UPDATE Submissions SET AssessmentId = @AssessmentId, StudentId = @StudentId, Score = @Score WHERE SubmissionId = @SubmissionId";
                    await dbConnection.ExecuteAsync(updateSql, submission);
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Failed to update submission.", ex);
            }
        }
    }
}
// Custom Exception Classes
public class DatabaseConnectionException : Exception
{
    public DatabaseConnectionException(string message, Exception innerException) : base(message, innerException) { }
}

public class DataValidationException : Exception
{
    public DataValidationException(string message) : base(message) { }
}

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}

public class ConcurrencyException : Exception
{
    public ConcurrencyException(string message) : base(message) { }
}

public class CustomUnauthorizedAccessException : Exception
{
    public CustomUnauthorizedAccessException(string message) : base(message) { }
}
public class SubmissionNotFoundException : Exception
{
    public SubmissionNotFoundException(string message) : base(message) { }
}
public class InvalidScoreException : Exception
{
    public InvalidScoreException(string message) : base(message) { }
}