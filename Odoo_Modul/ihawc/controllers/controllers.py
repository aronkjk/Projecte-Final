# -*- coding: utf-8 -*-
from odoo import http

# class Ihawc(http.Controller):
#     @http.route('/ihawc/ihawc/', auth='public')
#     def index(self, **kw):
#         return "Hello, world"

#     @http.route('/ihawc/ihawc/objects/', auth='public')
#     def list(self, **kw):
#         return http.request.render('ihawc.listing', {
#             'root': '/ihawc/ihawc',
#             'objects': http.request.env['ihawc.ihawc'].search([]),
#         })

#     @http.route('/ihawc/ihawc/objects/<model("ihawc.ihawc"):obj>/', auth='public')
#     def object(self, obj, **kw):
#         return http.request.render('ihawc.object', {
#             'object': obj
#         })