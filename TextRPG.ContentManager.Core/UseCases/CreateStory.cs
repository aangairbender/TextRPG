using TextRPG.Domain.Models;
using TextRPG.Domain.Validators;

namespace TextRPG.ContentManager.Core.UseCases
{
    public class CreateStoryRequest
    {
        public string Name { get; set; }
    }

    public class CreateStoryResponse
    {
        public bool Success { get; set; }
        public Story Story { get; set; }
    }

    public class CreateStory
    {
        public CreateStoryResponse Handle(CreateStoryRequest request)
        {
            var response = new CreateStoryResponse
            {
                Story = new Story(request.Name)
            };

            var validator = new StoryValidator();
            var validationResult = validator.Validate(response.Story);

            return response;
        }
    }
}
