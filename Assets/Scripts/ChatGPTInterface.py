import openai

class ChatGPTInterface:
    def __init__(self, model_name, api_key):
        self.model_name = model_name
        self.api_key = api_key
        openai.api_key = self.api_key
    
    def generate_response(self, message):
        response = openai.Completion.create(
            engine="davinci",
            prompt=message,
            max_tokens=50,
            n=1,
            stop=None,
            temperature=0.7
        )
        return response.choices[0].text.strip()
