# Jira Clone Wireframes (Atlassian Design System)

This document summarizes UI wireframes for a Jira clone. Components are based on the Atlassian Design System Figma library. Each wireframe references standard ADS patterns and components.

## App Layout
- **Sidebar** for project navigation (projects, boards, reports)
- **Top Bar** with project selector, search input, user avatar, and notifications
- **Main Content** area where pages render (boards, tickets, dashboards)

## Kanban Board Screen
Columns:
1. **To Do** – list of unstarted issues
2. **In Progress** – issues currently being worked on
3. **In Review** – items waiting for code or content review
4. **Done** – completed issues

Each column uses ADS cards for tickets, with drag-and-drop interactions.

## Issue Detail View
Fields:
- Title, status, priority, assignee
- Description using ADS editor component
- Comments section with nested replies
- Attachments area for file uploads

## Project Overview Dashboard
- Charts for issue counts by status and assignee
- Statistics on open vs closed issues, sprint velocity, etc.

## User & Project Management Screens
- List and manage projects (create, edit, delete)
- User management with roles and permissions

## Auth & Profile Pages
- Login form with ADS text fields and buttons
- Registration form for new users
- Profile page to edit avatar and personal information

> **Note**: This repo does not include the Figma design files themselves. To implement the wireframes, recreate these layouts in Figma using the Atlassian Design System component library.

