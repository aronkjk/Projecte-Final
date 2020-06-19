# -*- coding: utf-8 -*-

from odoo import models, fields, api
from openerp.exceptions import ValidationError

class player(models.Model):
    _name = 'res.partner'
    _inherit = 'res.partner'

    game_user = fields.Char()
    user_pass = fields.Char()
    game_coins = fields.Integer()
    skins = fields.Many2many('ihawc.skin')
    is_player = fields.Boolean(default=False)

class skin(models.Model):
    _name = 'ihawc.skin'
    name = fields.Char()
    image = fields.Binary()
    image_small = fields.Binary(string='Image', compute='_get_images', store=True)

    price = fields.Integer()

    type_skin = fields.Selection([('0', 'Default'), ('1', 'Normal'), ('2', 'Rare'),
                            ('3', 'Epic'), ('4', 'Legendary'), ('5', 'Uktimate')])

    owners = fields.Many2many('res.partner')
    package = fields.Many2one('ihawc.pack')

class pack(models.Model):
    _name = 'ihawc.pack'
    name = fields.Char()
    image = fields.Binary()
    image_small = fields.Binary(string='Image', compute='_get_images', store=True)

    price = fields.Integer()

    owners = fields.One2many('ihawc.skin', 'package')


