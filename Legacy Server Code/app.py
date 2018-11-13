from Block import Blockchain, Block
from flask import Flask, jsonify, request
import json
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
    #iter = blockchain.head
    #response = ''
    #while iter != None:
        #print(inum)
        # response = response + iter
        # iter = iter.next
    response = {
        'Message' : "You did it!",
        'Block' : "This Block"
    }
    return jsonify(response), 200

@app.route("/GetChain", methods = ['GET'])
def GetChain():
    itr = blockchain.head
    toGameJsn = {}
    toGameJsn[itr.blockNo] = {
        'BlockNumber' : itr.blockNo,
        'Hash' : str(itr.hash()),
        'Previous Hash' : itr.previousHash,
        'Data' : itr.data
    }
    itr = itr.next
    while itr != None:
        toGameJsn[itr.blockNo] = {
            'BlockNumber' : itr.blockNo,
            'Hash' : str(itr.hash()),
            'Previous Hash' : itr.previousHash,
            'Data' : itr.data
        }

        itr = itr.next

    return jsonify(json.dumps(toGameJsn)), 200
