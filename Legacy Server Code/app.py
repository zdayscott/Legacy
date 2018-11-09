from Block import Blockchain, Block
from flask import Flask, jsonify, request
app = Flask(__name__)

blockchain = Blockchain()

@app.route("/")
def home():
    return "Hello, Flask!"

@app.route('/SendWeapon/GametoServer', methods = ['POST'])
def GametoServer():
    values = request.get_json()
    print(values)

    required = ['name', 'discription', 'damage', 'attackSpeed']

    if not all(k in values for k in required):
        return 'Missing data', 400

    # Create a new block
    blockchain.mine(Block(values))
    return 'Success'

@app.route("/PrintData", methods = ['GET'])
def PrintChain():
    # Print out each block in the blockchain
    inum = blockchain.head
    while inum != None:
        print(inum)
        inum = inum.next
    return 'True'
