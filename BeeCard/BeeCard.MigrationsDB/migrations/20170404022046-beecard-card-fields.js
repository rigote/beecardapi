'use strict';

var dbm;
var type;
var seed;

/**
  * We receive the dbmigrate dependency from dbmigrate initially.
  * This enables us to not have to rely on NODE_PATH.
  */
exports.setup = function(options, seedLink) {
  dbm = options.dbmigrate;
  type = dbm.dataType;
  seed = seedLink;
};

exports.up = function(db, callback) {
    //Company
    db.addColumn('Company', 'Address2', { type: 'string', notNull: false, length: 150 }, callback);
    db.addColumn('Company', 'Number', { type: 'string', notNull: true, length: 10 }, callback);

    //Personal Card
    db.addColumn('PersonalCard', 'Address2', { type: 'string', notNull: false, length: 150 }, callback);
    db.addColumn('PersonalCard', 'Number', { type: 'string', notNull: false, length: 10 }, callback);
    db.addColumn('PersonalCard', 'City', { type: 'string', notNull: false, length: 100 }, callback);
    db.addColumn('PersonalCard', 'PostalCode', { type: 'string', notNull: false, length: 20 }, callback);
    db.addColumn('PersonalCard', 'Neighborhood', { type: 'string', notNull: false, length: 100 }, callback);
};

exports.down = function(db) {
  return null;
};

exports._meta = {
  "version": 1
};
