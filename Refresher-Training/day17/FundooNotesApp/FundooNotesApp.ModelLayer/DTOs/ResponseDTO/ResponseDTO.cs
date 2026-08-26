namespace FundooNotesApp.ModelLayer.DTOs.ResponseDTO;

// Every endpoint in this API replies using this SAME envelope shape, so
// the frontend always knows what to expect:
//   { "success": true/false, "message": "...", "data": ... }
//
// The <T> makes it generic - "data" can be a plain string (like a JWT
// token) or any other payload, without needing a new class each time.
public class ResponseDTO<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = "";
    public T? Data { get; set; }
}
