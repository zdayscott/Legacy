from Block import Blockchain, Block
from flask import Flask, jsonify, request
app = Flask(__name__)

Blockchain

@app.route("/")
def home():
    return "Hello, Flask!"

@app.route('/SendWeapon/GametoServer', methods = ['POST'])
def GametoServer():
    values = request.get_json()

    required = ['name', 'discription', 'damage', 'attackSpeed']

    if not all(k in values for k in required):
        return 'Missing data', 400

    # Create a new block
    Blockchain.mine(Block(values))

@app.route("/PrintData", methods = ['GET'])
def PrintChain():
    # Print out each block in the blockchain
    while blockchain.head != None:
        print(blockchain.head)
        blockchain.head = blockchain.head.next
    return True
