from flask import Flask, jsonify, request
from models import db, Expense, Income
from datetime import datetime

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///expenses.db'
db.init_app(app)

@app.route('/api/expense', methods=['POST'])
def add_expense():
    data = request.json
    expense = Expense(
        description=data['description'],
        amount=data['amount'],
        currency=data['currency'],
        date=datetime.utcnow()
    )
    print(expense.to_dict())
    db.session.add(expense)
    db.session.commit()
    return jsonify(expense.to_dict()), 201

@app.route('/api/income', methods=['POST'])
def add_income():
    data = request.json
    income = Income(
        description=data['description'],
        amount=data['amount'],
        currency=data['currency'],
        date=datetime.utcnow()
    )
    db.session.add(income)
    db.session.commit()
    return jsonify(income.to_dict()), 201

@app.route('/api/expenses', methods=['GET'])
def get_expenses():
    expenses = Expense.query.all()
    return jsonify([expense.to_dict() for expense in expenses])

@app.route('/api/incomes', methods=['GET'])
def get_incomes():
    incomes = Income.query.all()
    return jsonify([income.to_dict() for income in incomes])

if __name__ == '__main__':
    app.run(debug=True)
