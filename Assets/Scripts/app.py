from flask import Flask, request, jsonify
from ChatGPTInterface import ChatGPTInterface

app = Flask(__name__)

# 替换为你的OpenAI模型名称和API密钥
model_name = "gpt-3.5-turbo"
api_key = "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"

chatgpt = ChatGPTInterface(model_name, api_key)

@app.route('/chat', methods=['POST'])
def chat():
    data = request.get_json()
    message = data['message']
    response = chatgpt.generate_response(message)
    return jsonify({'response': response})

if __name__ == '__main__':
    app.run()
